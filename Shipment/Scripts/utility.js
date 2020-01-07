(function($) {
	jQuery.fn.exists = function(){return $(this).length > 0;}
	
	$(document).ready(function() {
	
		loading = function() {
			setTimeout(function () {
				var loadingImg = $("<img />").attr("src", "images/loading15.gif").load(function() {
					var imgWidth = this.width;
					var imgHeight = this.height;
	
					$(this).css({
						position: "absolute",
						left: ($("body")[0].clientWidth - imgWidth) / 2 + "px",
						top: ($("body")[0].clientHeight - imgHeight) / 2 + "px"
					});
					var modal = $("<div class=\"modal\"></div>").append($(this));
					$("body").append(modal).addClass("loading");
				});
			}, 200);
		}
	
        $('form').on("submit", function () {
            loading();
        });
		
		unloading = function() {
			setTimeout(function () {
				$("body").removeClass("loading");
				$("div.modal").remove();
			}, 2000);
		}
		
		$("input[type='submit'][value~='export' i],input[type='submit'][value~='download' i],input[type='submit'][value~='print' i]").attr("onclick", "unloading();");
		
		$(".datepicker").datepicker({
			showOn: "button",
			buttonImage: "images/calendar.gif",
			buttonImageOnly: true,
			buttonText: "Select date",
			showAnim: "slideDown"
		});
	});
	
})(jQuery);