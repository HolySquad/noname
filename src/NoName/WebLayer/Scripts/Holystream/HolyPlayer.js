function HolyPlayerVm() {
    var self = this;

    var internal = {
        playStopBtnId: "#playStop",
        audioPlayerId: "#player",
        audioItemClass: ".audioItem"
    };
    debugger;
    var songs = $(internal.audioItemClass);
    var currentNumber = 0;
    var $player = $(internal.audioPlayerId);

    self.togglePlay = function () {
        $(".audioItem")[currentNumber].toggleClass('bg-info');
        var startUrl = $(internal.audioItemClass)[currentNumber].id;
        $player.attr("src", startUrl);
        
    };

    self.forward = function() {
        if (currentNumber + 1 > songs.count) {
            alert("Next page please");
            return false;
        }
        $(internal.audioItemClass)[currentNumber].toggleClass('bg-info');
        var startUrl = $(internal.audioItemClass)[currentNumber + 1].id;
        $player.attr("src", startUrl);  
        $player.get(0).play();
    };

    self.back = function() {
        if (currentNumber - 1 < 0) {
            alert("No way back!");
            return false;
        } else {
            $(internal.audioItemClass)[currentNumber].toggleClass('bg-info');
            var startUrl = $(internal.audioItemClass)[currentNumber + 1].id;
            $player.attr("src", startUrl);
            $player.get(0).play();
            return false;
        }
    };

    internal.highlightSong = function () {
        debugger;
        $(internal.audioItemClass)[currentNumber].toggleClass('bg-info');
        $player.get(0).play();
       
    };
};