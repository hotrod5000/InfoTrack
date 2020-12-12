﻿
function ViewModel() {
    var self = this;
    self.keywords = "online title search";
    self.url = "ever";
    self.results = ko.observableArray();
    self.clickHandler = function () {
        let searchWords = self.keywords.split(' ');
        let apiEndpoint = '/Scrape/GetSearchResults?url=' + self.url;
        for (var i = 0; i < searchWords.length; i++) {
            apiEndpoint += '&term=' + searchWords[i];
        }
        $.get(apiEndpoint, function (data) {
            self.results(data);

        });
    };
}

ko.applyBindings(new ViewModel());