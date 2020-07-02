import * as React from "react";
import { ILocalizationState } from './interfaces/ILocalizationState';
import { IDefaultProps } from "./interfaces/IDefault";
import { Localization } from "./models/Localization";

export class FetchData extends React.Component<IDefaultProps, ILocalizationState> {
  static displayName = FetchData.name;

  constructor(props : IDefaultProps) {
      super(props);
      this.state = { localizations: new Array<Localization>(), loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

    static renderForecastsTable(localizations : Localization[]) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Lokalizacja</th>
            <th>Opinia</th>
            <th>Średnia ocena</th>
          </tr>
        </thead>
        <tbody>
          {localizations.map(localization =>
              <tr key={localization.locID}>
              <td>{localization.locName}</td>
              <td>{localization.locDescription}</td>
              <td>{localization.locRatingsAvg}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : FetchData.renderForecastsTable(this.state.localizations);

    return (
      <div>
        <h1 id="tabelLabel" >Localizations</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch("https://thumbupapp.azurewebsites.net/api/Localizations");
    const data = await response.json();
    this.setState({ localizations: data, loading: false });
  }
}
