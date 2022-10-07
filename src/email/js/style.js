var ugly_selectorText_workaround_flag = false;
var allStyleRules;
function ugly_selectorText_workaround() {
	if((navigator.userAgent.indexOf("Gecko") == -1) ||
	   (ugly_selectorText_workaround_flag)) {
		return; 
	}
	var styleElements = document.getElementsByTagName("style");
	
	for(var i = 0; i < styleElements.length; i++) {
		var styleText = styleElements[i].firstChild.data;
		allStyleRules = styleText.match(/\b[\w-.]+(\s*\{)/g);
	}

	for(var i = 0; i < allStyleRules.length; i++) {
		allStyleRules[i] = allStyleRules[i].substr(0, (allStyleRules[i].length - 2));
	}
	ugly_selectorText_workaround_flag = true;
}
function setStyleById(i, p, v) {
	var n = document.getElementById(i);
	n.style[p] = v;
}
function getStyleById(i, p) {
	var n = document.getElementById(i);
	var s = eval("n.style." + p);

	if((s != "") && (s != null)) {
		return s;
	}

	if(n.currentStyle) {
		var s = eval("n.currentStyle." + p);
		if((s != "") && (s != null)) {
			return s;
		}
	}
	
	var sheets = document.styleSheets;
	if(sheets.length > 0) {
		for(var x = 0; x < sheets.length; x++) {
			var rules = sheets[x].cssRules;
			if(rules.length > 0) {
				for(var y = 0; y < rules.length; y++) {
					var z = rules[y].style;
					ugly_selectorText_workaround();
					if(allStyleRules) {
						if(allStyleRules[y] == i) {
							return z[p];
						}			
					} else {
						if(((z[p] != "") && (z[p] != null)) ||
						   (rules[y].selectorText == i)) {
							return z[p];
						}
					}
				}
			}
		}
	}
	return null;
}
var ie = (document.all) ? true : false;

function setStyleByClass(t,c,p,v){
	var elements;
	if(t == '*') {
		elements = (ie) ? document.all : document.getElementsByTagName('*');
	} else {
		elements = document.getElementsByTagName(t);
	}
	for(var i = 0; i < elements.length; i++){
		var node = elements.item(i);
		for(var j = 0; j < node.attributes.length; j++) {
			if(node.attributes.item(j).nodeName == 'class') {
				if(node.attributes.item(j).nodeValue == c) {
					eval('node.style.' + p + " = '" +v + "'");
				}
			}
		}
	}
}
function getStyleByClass(t, c, p) {
	var elements;
	if(t == '*') {
		elements = (ie) ? document.all : document.getElementsByTagName('*');
	} else {
		elements = document.getElementsByTagName(t);
	}
	for(var i = 0; i < elements.length; i++){
		var node = elements.item(i);
		for(var j = 0; j < node.attributes.length; j++) {
			if(node.attributes.item(j).nodeName == 'class') {
				if(node.attributes.item(j).nodeValue == c) {
					var theStyle = eval('node.style.' + p);
					if((theStyle != "") && (theStyle != null)) {
						return theStyle;
					}
				}
			}
		}		
	}
	var sheets = document.styleSheets;
	if(sheets.length > 0) {
		for(var x = 0; x < sheets.length; x++) {
			var rules = sheets[x].cssRules;
			if(rules.length > 0) {
				for(var y = 0; y < rules.length; y++) {
					var z = rules[y].style;
					ugly_selectorText_workaround();
					if(allStyleRules) {
						if((allStyleRules[y] == c) ||
						   (allStyleRules[y] == (t + "." + c))) {
							return z[p];
						}			
					} else {
						if(((z[p] != "") && (z[p] != null)) &&
						   ((rules[y].selectorText == c) ||
						    (rules[y].selectorText == (t + "." + c)))) {
							return z[p];
						}
					}
				}
			}
		}
	}

	return null;
}
function setStyleByTag(e, p, v, g) {
	if(g) {
		var elements = document.getElementsByTagName(e);
		for(var i = 0; i < elements.length; i++) {
			elements.item(i).style[p] = v;
		}
	} else {
		var sheets = document.styleSheets;
		if(sheets.length > 0) {
			for(var i = 0; i < sheets.length; i++) {
				var rules = sheets[i].cssRules;
				if(rules.length > 0) {
					for(var j = 0; j < rules.length; j++) {
						var s = rules[j].style;
						ugly_selectorText_workaround();
						if(allStyleRules) {
							if(allStyleRules[j] == e) {
								s[p] = v;
							}			
						} else {
							if(((s[p] != "") && (s[p] != null)) &&
							   (rules[j].selectorText == e)) {
								s[p] = v;
							}
						}

					}
				}
			}
		}
	}
}
function getStyleByTag(e, p) {
	var sheets = document.styleSheets;
	if(sheets.length > 0) {
		for(var i = 0; i < sheets.length; i++) {
			var rules = sheets[i].cssRules;
			if(rules.length > 0) {
				for(var j = 0; j < rules.length; j++) {
					var s = rules[j].style;
					ugly_selectorText_workaround();
					if(allStyleRules) {
						if(allStyleRules[j] == e) {
							return s[p];
						}			
					} else {
						if(((s[p] != "") && (s[p] != null)) &&
						   (rules[j].selectorText == e)) {
							return s[p];
						}
					}

				}
			}
		}
	}
	var elements = document.getElementsByTagName(e);
	var sawClassOrStyleAttribute = false;
	for(var i = 0; i < elements.length; i++) {
		var node = elements.item(i);
		for(var j = 0; j < node.attributes.length; j++) {
			if((node.attributes.item(j).nodeName == 'class') ||
			   (node.attributes.item(j).nodeName == 'style')){
			   sawClassOrStyleAttribute = true;
			}
		}
		if(! sawClassOrStyleAttribute) {
			return elements.item(i).style[p];
		}
	}
}
