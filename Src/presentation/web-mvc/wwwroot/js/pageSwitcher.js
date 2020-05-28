'use strict'

class SwitchPage {
    constructor(placeToLoad, urlAction, paramValue) {
        this.placeToLoad = placeToLoad;
        this.urlAction = urlAction;
        this.paramValue = paramValue;
    }
    pageLoad(paramValue) {
        $(this.placeToLoad).load(this.urlAction, { currentPage: paramValue });
    }
    switcher(selector, attr) {
        const self = this;
        $('body').on('click', selector, function () {
            $(self.placeToLoad).load(self.urlAction, { currentPage: $(this).attr(attr) })
        })
    };
}