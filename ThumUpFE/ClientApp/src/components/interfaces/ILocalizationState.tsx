import { Localization } from "../models/Localization";

export interface ILocalizationState {
    localizations: Localization[];
    loading: boolean;
}