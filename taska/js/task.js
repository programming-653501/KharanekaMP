$(document).ready( function () {
	
	document.getElementById("content").style.display = "none";
	var activeMovie = 0;
	var movies;
	var animationFlag = false;
	
	var filling = function(film) { // Функция заполнения карусели.
		if (film.poster_path !== null) {
			var img = new Image();
			img.src = "http://image.tmdb.org/t/p/w185" + film.poster_path; // Загружаем картинку в кэш, пока следует анимация.
		}
		
		setTimeout( function () {
			$("#content").fadeIn(700, function () {animationFlag = false;});
			$("#title H2").html(film.title);
			if (film.poster_path !== null) {
				$("#content img").attr("src", "http://image.tmdb.org/t/p/w185" + film.poster_path);
			}
			else {
				$("#content img").attr("src", "resources/no_title.png");
			};
			$("#tTitle").html(film.title);
			$("#oTitle").html(film.original_title);
			$("#year").html(film.release_date);
			$("#popularity").html(film.popularity);
			$("#rate").html(film.vote_average);
			$("#oLanguage").html(film.original_language);
			$("#voteCount").html(film.vote_count);
			$("#review").html(film.overview);
		}, 700);
	};
	
	var randInt = function (min, max) { // Целое рандомное число.
		return Math.floor(Math.random() * (max - min) + min);
	}
	
	var randomMovies = function () {
		var rMovies = []; // Массив рандомных фильмов.
		var latestId;
		var threads = 0;  	// Так как каждый из фильмов будет запрашиваться асинхронно 
							// и необязательно по порядку, будем считать количество обработанных запросов, пока не достигнут 5.
		tmdb.call("/movie/latest", {language : "en-US"}, function (data) { // Получаем последний id.
			latestId = data["id"];
			for (var i = 0; i < 5; i++) { 
				(function get(value) {
					var id = randInt(62, latestId);
					tmdb.call("/movie/" + id, {}, function (film) { // В случае успешного запроса добавляем фильм.
						if (film.adult) {
							get(value);
						}
						rMovies[value] = film;
						threads++;
						if (threads === 5) {
							movies = rMovies;
							activeMovie = 0;
							filling(movies[0]);		// При получении всех 5 фильмов, заполняем карусель.
						}
				}, function (data) {get(value)})}(i)); // В случае неудачного запроса (фильм с таким id был удален) 
													   // вызываем get снова с тем же значением итератора.
			};			
		}, function () {});
	};
	
	
	randomMovies();
	
	$("#search").click( function (event) { // Обработка поискового запроса.
		if (!animationFlag) { // Анимация будет выполняться только один раз при множественном нажатии.
			$("#content").fadeOut(700);
			animationFlag = true;
		}
		var query = $("#query").val();
		$("#right").attr("disabled", false);
		$("#left").attr("disabled", true);
		if (query === "") {
			randomMovies();
			animationFlag = false;
			return;
		};
		
		tmdb.call("/search/movie", {
			"query" : query
		}, function (data) {
			movies = data.results;
			activeMovie = 0;
			filling(movies[0]);
		}, function () {
			alert("Oops, something went wrong...");
		});

	});
	
	$("#left").click( function () { // Кнопка влево.
		if (!animationFlag) { 
			$("#content").fadeOut(700);
			animationFlag = true;
		}
		activeMovie--;
		if (activeMovie === 0) {
			$("#left").attr("disabled", true);
		};
		if (activeMovie === movies.length - 2 || activeMovie === 8) {
			$("#right").attr("disabled", false);
		};
		filling(movies[activeMovie]);
	});
	
	$("#right").click( function () { // Кнопка вправо.
		if (!animationFlag) {
			$("#content").fadeOut(700);
			animationFlag = true;
		}
		activeMovie++;
		if (activeMovie === 1) {
			$("#left").attr("disabled", false);
		}
		if (activeMovie === movies.length - 1 || activeMovie === 9) {
			$("#right").attr("disabled", true);
		}
		filling(movies[activeMovie]);
	});
	
});