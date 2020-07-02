import 'bootstrap/dist/css/bootstrap.css';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { ApplicationInsights } from '@microsoft/applicationinsights-web'

const appInsights = new ApplicationInsights({
    config: {
        instrumentationKey: 'aa373450-68f1-46b2-bf8b-49d5ae392931'
    }
});
appInsights.loadAppInsights();
appInsights.trackPageView();

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl!}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();

