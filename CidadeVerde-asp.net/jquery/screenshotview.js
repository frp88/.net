jQuery(document).ready(function($) {
    xOffset = 10;
    yOffset = 100;

    $(".screenshot").hover(function(e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "<br/>" + this.t : "";
        $("body").append("<center><p id='screenshot'><img src='" + this.src + "' alt='url preview' />" + c + "</p></center>");
        $("#screenshot")
			.css("top", (e.pageY - 250) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("fast");
    },
	function() {
	    this.title = this.t;
	    $("#screenshot").remove();
	});
    $(".screenshot").mousemove(function(e) {
        $("#screenshot")
			.css("top", (e.pageY - 250) + "px")
			.css("left", (e.pageX + yOffset) + "px");
    });
});