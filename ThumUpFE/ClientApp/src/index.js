"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("bootstrap/dist/css/bootstrap.css");
var React = require("react");
var ReactDOM = require("react-dom");
var react_router_dom_1 = require("react-router-dom");
var App_1 = require("./App");
var registerServiceWorker_1 = require("./registerServiceWorker");
var applicationinsights_web_1 = require("@microsoft/applicationinsights-web");
var appInsights = new applicationinsights_web_1.ApplicationInsights({
    config: {
        instrumentationKey: 'aa373450-68f1-46b2-bf8b-49d5ae392931'
    }
});
appInsights.loadAppInsights();
appInsights.trackPageView();
var baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
var rootElement = document.getElementById('root');
ReactDOM.render(React.createElement(react_router_dom_1.BrowserRouter, { basename: baseUrl },
    React.createElement(App_1.default, null)), rootElement);
registerServiceWorker_1.default();
//# sourceMappingURL=index.js.map