import { Injectable } from '@angular/core';
import { ConfigurationBuilders, FrontendSettings } from './configuration/configuration-builders';
import { ConfigurationDictionary } from './configuration/configuration-dictionary';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  get apiBaseUrl(): string {
    const baseUrl = ConfigurationDictionary.GetConfig('ApiBaseUrl');

    if (!baseUrl) {
      throw new Error('ApiBaseUrl is not configured.');
    }

    return baseUrl.replace(/\/$/, '');
  }

  async load(): Promise<void> {
    const response = await fetch('/frontend-appsettings.json');

    if (!response.ok) {
      throw new Error('Unable to load frontend-appsettings.json.');
    }

    const settings = await response.json() as FrontendSettings;
    ConfigurationBuilders.buildConfiguration(settings);
  }
}
