function BrowserIdentification() {
	var b = navigator.appName
	if (b=="Netscape") this.b = "ns"
	else if (b=="Microsoft Internet Explorer") this.b = "ie"
	else this.b = b
	this.version = navigator.appVersion
	this.v = parseInt(this.version)
	this.ns = (this.b=="ns" && this.v>=4)
	this.ns4 = (this.b=="ns" && this.v==4)
	this.ns5 = (this.b=="ns" && this.v==5)
	this.ie = (this.b=="ie" && this.v>=4)
	this.ie4 = (this.version.indexOf('MSIE 4')>0)
	this.ie5 = (this.version.indexOf('MSIE 5')>0)
	this.min = (this.ns||this.ie)
}

function membernameHTML()
{	
	if( !membername ) { return '' };

	var nameString = '<img src="' + imageBase + '/' + 'left.gif" border=0 />'
	
	for( var i = 0; i < membername.length; ++i)
	{
		var filename = membername.charAt(i);
		if (filename == '_') {
			filename = 'underscore';
		} else if (filename == '.') {
			filename = 'dot';
		}
		nameString += '<img src="' + imageBase + '/' + filename + '.gif" border=0 />';
	}
	
	nameString += '<img src="' + imageBase + '/' + 'right.gif" border=0 />';
	
	return nameString;
}

function writeMembername()
{
	var membernameHTMLString = membernameHTML();

	if( membernameHTMLString.length )
	{		
		if(typeof(document.getElementById) == 'function') {
			document.getElementById('MembernameDiv').innerHTML = membernameHTMLString;
		}
		else if( !browserIs.ns )//if( browserIs.ie )
		{
			document.all['MembernameDiv'].innerHTML = membernameHTMLString;
		}
    }
	return false;
}

function getCookie(name) {
  var dc = document.cookie;
  var prefix = name + "=";
  var begin = dc.indexOf("; " + prefix);
  if (begin == -1) {
    begin = dc.indexOf(prefix);
    if (begin != 0) return null;
  } else
    begin += 2;
  var end = document.cookie.indexOf(";", begin);
  if (end == -1)
    end = dc.length;
  return unescape(dc.substring(begin + prefix.length, end));
}

function getMembername()
{
	return getCookie('nb');
}

var browserIs = new BrowserIdentification()
var membername = getMembername();
var imageBase = '/i/ma/1/nav_aqua/let';
var loginDiv;
var logoutDiv

if(typeof(document.getElementById) == 'function') {
	loginDiv = document.getElementById('LoginLinkDiv');
	logoutDiv = document.getElementById('LogoutLinkDiv');
} else {
	loginDiv = document.all['LoginLinkDiv'];
	logoutDiv = document.all['LogoutLinkDiv'];
}

if ((loginDiv) && (logoutDiv)) {
	if (membername) {
		writeMembername();
		loginDiv.style.display = "none";
		logoutDiv.style.display = "";
	} else {
		loginDiv.style.display = "";
		logoutDiv.style.display = "none";
	}
}
