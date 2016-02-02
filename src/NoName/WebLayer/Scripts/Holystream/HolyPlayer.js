﻿function HolyPlayerVm() {
    var self = this;

    var internal = {
        playStopBtnId: "#playStop",
        audioPlayerId: "#player",
        audioItemClass: ".audioItem"
    };

    var songs = $(internal.audioItemClass);
    var currentNumber = 0;
    var $player = $(internal.audioPlayerId);

   

    self.togglePlay = function (x) {
        
        if (x != undefined) {
            var specificSong = $(internal.audioItemClass)[x.rowIndex].getAttribute("value");
            $player.attr("src", specificSong);
            currentNumber = x.rowIndex;
            internal.highlightSong(false, x.rowIndex);
            internal.play();
            return false;
        };
        if (!$player.get(0).paused) {
            internal.pause();
            return false;
        } else {
            internal.highlightSong(false, currentNumber);
            internal.play();
        }
        if ($player.attr("src") == undefined) {
            var startUrl = $(internal.audioItemClass)[currentNumber].getAttribute("value");
            $player.attr("src", startUrl);
            internal.highlightSong(false, currentNumber);
            internal.play(true);
        }
    };

    $player.on("timeupdate", function () {
        var currentTime = $player.get(0).currentTime;
        var duration = $player.get(0).duration;
        var convertedTime = internal.convertSecondsToTimeForPlayer(currentTime);
        var fullTime = internal.convertSecondsToTimeForPlayer(duration);
        $("#timeState").text(convertedTime + "/" + fullTime);

    });

    $player.on("ended", function () {
        self.forward();
    });

    self.forward = function() {
        if (currentNumber + 1 > songs.count) {
            alert("Next page please");
            return false;
        }

        var startUrl = $(internal.audioItemClass)[currentNumber += 1].getAttribute("value");
        $player.attr("src", startUrl);  
        internal.highlightSong(true, currentNumber);
        internal.play();
    };

    self.back = function() {
        if (currentNumber - 1 < 0) {
            alert("No way back!");
            return false;
        } else {
            var startUrl = $(internal.audioItemClass)[currentNumber -= 1].getAttribute("value");
            $player.attr("src", startUrl);
            internal.highlightSong(true, currentNumber);
            internal.play();
            return false;
        }
    };

    internal.highlightSong = function (changePosition, songNumber) {
        if (songNumber != 0) {

            $("tr")[songNumber - 1].style.backgroundColor = "white";
            $("tr")[songNumber + 1].style.backgroundColor = "white";
        }
            $("tr")[songNumber].style.backgroundColor = "#B8D8F3";
       
        var currentSong = $(internal.audioItemClass)[songNumber].attributes[1].nodeValue;
        $("#playerCurrentSong").text(currentSong);
    };

    internal.iconPlayState = function () {
        if ($(".playStop").hasClass("fa-play")) {
            $(".playStop").toggleClass("fa-play");
            $(".playStop").toggleClass("fa-pause");
        }
    };
    
    internal.iconPauseState = function () {
        if ($(".playStop").hasClass("fa-pause")) {
            $(".playStop").toggleClass("fa-pause");
            $(".playStop").toggleClass("fa-play");
        }
    }

    internal.play = function () {
        $player.get(0).play();
        internal.iconPlayState();
    };

    internal.pause = function () {
        $player.get(0).pause();
        internal.iconPauseState();
    };

    internal.convertSecondsToTimeForPlayer = function (secondsTime) {
        var minutes = parseInt(secondsTime / 60) % 60;
        var seconds = secondsTime % 60;

        return (minutes < 10 ? "0" + minutes : minutes) + ":" + (seconds.toPrecision(2) < 10 ? "0" + seconds.toPrecision(2) : seconds.toPrecision(2));
    };
};