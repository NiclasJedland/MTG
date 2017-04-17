var highlightedList = [];
$(document).ready(function () {
	$(".set div").click(function () {
		$(this).parent().next().slideToggle(0);
		$(this).parent().toggleClass("highlighted");
		//convert NodeList to Array
		highlightedList = Array.prototype.slice.call(document.querySelectorAll(".highlighted"));
	})
});

function getHighlighted() {
	alert("woo");
	return highlightedList.join(" ");
}