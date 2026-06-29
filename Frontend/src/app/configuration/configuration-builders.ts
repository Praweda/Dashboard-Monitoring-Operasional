import { ConfigurationDictionary } from './configuration-dictionary';

export interface FrontendSettings {
  api?: {
    baseUrl?: string;
  };
}

export class ConfigurationBuilders {
  static buildConfiguration(settings: FrontendSettings): void {
    const apiBaseUrl = settings.api?.baseUrl;

    if (!apiBaseUrl) {
      throw new Error('Api:BaseUrl is not configured.');
    }

    ConfigurationDictionary.ReadConfig('ApiBaseUrl', apiBaseUrl);
  }
}
