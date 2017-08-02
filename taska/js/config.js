(function () {
	window.carousel_cfg = {
		"fadingTime" : 700,
		"picturesPath" : "http://image.tmdb.org/t/p/w185",
		"emptyFadingTime" : 300,
		"moviesNumber" : 10,
		"randomMoviesNumber" : 5,
		"enableRight" : function () {
			return this.moviesNumber - 2;
			}, 
		"disableRight" : function () {
			return this.moviesNumber - 1;
			}
	};
}());