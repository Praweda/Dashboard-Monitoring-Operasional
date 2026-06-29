export class ConfigurationDictionary {
  private static readonly configMap = new Map<string, string>();

  static ReadConfig(key: string, value: string): void {
    this.configMap.set(key, value);
  }

  static GetConfig(key: string): string | undefined {
    return this.configMap.get(key);
  }
}
