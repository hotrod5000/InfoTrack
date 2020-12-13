
function ViewModel() {
    var self = this;
    self.keywords = ko.observable();
    self.url = "";
    self.results = ko.observableArray();
    self.resultsSummary = ko.observable();
    self.haveResults = ko.observable(false);
    self.loader = ko.observable();
    self.isError = ko.observable(false);
    self.clickHandler = function () {
        let searchWords = self.keywords().split(' ');
        let apiEndpoint = '/Scrape/GetSearchResults?url=' + self.url;
        for (var i = 0; i < searchWords.length; i++) {
            apiEndpoint += '&term=' + searchWords[i];
        }

        self.haveResults(false);
        self.loader("loader");
        self.isError(false);
        
        $.get(apiEndpoint, function (data) {
            self.results(data.Results);
            self.resultsSummary(data.Summary);
            self.haveResults(true);

        }).always(function () {
            self.loader("");
        }).fail(function () {
            self.isError(true);
        });
        
        
    };
}

ko.applyBindings(new ViewModel());