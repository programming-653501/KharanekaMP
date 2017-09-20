!function(e,t){"object"==typeof exports&&"object"==typeof module?module.exports=t(require("underscore"),require("backbone")):"function"==typeof define&&define.amd?define(["underscore","backbone"],t):"object"==typeof exports?exports["Backbone.LocalStorage"]=t(require("underscore"),require("backbone")):e["Backbone.LocalStorage"]=t(e._,e.Backbone)}(this,function(e,t){return function(e){function t(n){if(r[n])return r[n].exports;var o=r[n]={i:n,l:!1,exports:{}};return e[n].call(o.exports,o,o.exports,t),o.l=!0,o.exports}var r={};return t.m=e,t.c=r,t.i=function(e){return e},t.d=function(e,r,n){t.o(e,r)||Object.defineProperty(e,r,{configurable:!1,enumerable:!0,get:n})},t.n=function(e){var r=e&&e.__esModule?function(){return e.default}:function(){return e};return t.d(r,"a",r),r},t.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},t.p="",t(t.s=7)}([function(e,t,r){"use strict";(function(e){function n(){return(0|65536*(1+Math.random())).toString(16).substring(1)}function o(){return""+n()+n()+"-"+n()+"-"+n()+"-"+n()+"-"+n()+n()+n()}function i(e){return(0,u.result)(e,"localStorage")||(0,u.result)(e.collection,"localStorage")}function a(){return(0,u.isUndefined)(window)?e:window}Object.defineProperty(t,"__esModule",{value:!0}),t.guid=o,t.getLocalStorage=i,t.getWindow=a;var u=r(1)}).call(t,r(6))},function(t,r){t.exports=e},function(e,r){e.exports=t},function(e,t,r){"use strict";function n(e){return e&&e.__esModule?e:{default:e}}function o(e){var t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{},r=t.ajaxSync,n=(0,s.getLocalStorage)(e);return!r&&n?c.sync:l}Object.defineProperty(t,"__esModule",{value:!0}),t.LocalStorage=void 0;var i=r(2),a=n(i),u=r(4),c=r(5),s=r(0);a.default.LocalStorage=u.LocalStorage;var l=a.default.sync;a.default.sync=function(e,t,r){return o(t,r).apply(this,[e,t,r])},t.LocalStorage=u.LocalStorage},function(e,t,r){"use strict";function n(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(t,"__esModule",{value:!0}),t.LocalStorage=void 0;var o=function(){function e(e,t){for(var r=0;r<t.length;r++){var n=t[r];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(e,n.key,n)}}return function(t,r,n){return r&&e(t.prototype,r),n&&e(t,n),t}}(),i=r(1),a=r(0),u={serialize:function(e){return(0,i.isObject)(e)?JSON.stringify(e):e},deserialize:function(e){return e&&JSON.parse(e)}};t.LocalStorage=function(){function e(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"",r=arguments.length>1&&void 0!==arguments[1]?arguments[1]:u;if(n(this,e),this.name=t,this.serializer=r,!this.localStorage)throw"Backbone.localStorage: Environment does not support localStorage.";var o=this._getItem(this.name);this.records=o&&o.split(",")||[]}return o(e,[{key:"localStorage",value:function(){return(0,a.getWindow)().localStorage}},{key:"save",value:function(){this._setItem(this.name,this.records.join(","))}},{key:"create",value:function(e){return e.id||0===e.id||(e.id=(0,a.guid)(),e.set(e.idAttribute,e.id)),this._setItem(this._itemName(e.id),this.serializer.serialize(e)),this.records.push(e.id.toString()),this.save(),this.find(e)}},{key:"update",value:function(e){this._setItem(this._itemName(e.id),this.serializer.serialize(e));var t=e.id.toString();return(0,i.contains)(this.records,t)||(this.records.push(t),this.save()),this.find(e)}},{key:"find",value:function(e){return this.serializer.deserialize(this._getItem(this._itemName(e.id)))}},{key:"findAll",value:function(){var e=this;return(0,i.chain)(this.records).map(function(t){return e.serializer.deserialize(e._getItem(e._itemName(t)))}).filter(function(e){return null!=e}).value()}},{key:"destroy",value:function(e){this._removeItem(this._itemName(e.id));var t=(0,i.without)(this.records,e);return this.records=t,this.save(),e}},{key:"_clear",value:function(){var e=this.localStorage(),t=new RegExp("^"+this.name+"-");e.removeItem(this.name);for(var r in e)t.test(r)&&e.removeItem(r);this.records.length=0}},{key:"_storageSize",value:function(){return this.localStorage().length}},{key:"_getItem",value:function(e){return this.localStorage().getItem(e)}},{key:"_itemName",value:function(e){return this.name+"-"+e}},{key:"_setItem",value:function(e,t){this.localStorage().setItem(e,t)}},{key:"_removeItem",value:function(e){this.localStorage().removeItem(e)}}]),e}()},function(e,t,r){"use strict";function n(e){return e&&e.__esModule?e:{default:e}}function o(){return u.default.$?(0,c.result)(u.default.$,"Deferred",!1):(0,c.result)(u.default,"Deferred",!1)}function i(e,t){var r=arguments.length>2&&void 0!==arguments[2]?arguments[2]:{},n=(0,s.getLocalStorage)(t),i=void 0,a=void 0,u=o();try{switch(e){case"read":i=(0,c.isUndefined)(t.id)?n.findAll():n.find(t);break;case"create":i=n.create(t);break;case"patch":case"update":i=n.update(t);break;case"delete":i=n.destroy(t)}}catch(e){a=22===e.code&&0===n._storageSize()?"Private browsing is unsupported":e.message}return i?(r.success&&r.success.call(t,i,r),u&&u.resolve(i)):(a=a?a:"Record Not Found",r.error&&r.error.call(t,a,r),u&&u.reject(a)),r.complete&&r.complete.call(t,i),u&&u.promise()}Object.defineProperty(t,"__esModule",{value:!0}),t.sync=i;var a=r(2),u=n(a),c=r(1),s=r(0)},function(e,t){var r;r=function(){return this}();try{r=r||Function("return this")()||(0,eval)("this")}catch(e){"object"==typeof window&&(r=window)}e.exports=r},function(e,t,r){e.exports=r(3)}])});
