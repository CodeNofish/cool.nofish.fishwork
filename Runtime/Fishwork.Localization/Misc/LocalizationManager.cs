using System.Collections.Generic;
using System.Globalization;

namespace Fishwork.Localization {

  public class LocalizationManager {
    public Language DefaultLanguage = new() {
      LanguageType = LanguageType.Chinese,
      CultureInfo = CultureInfo.GetCultureInfo("zh")
    };

    public List<Language> SupportedLanguages;
    
    public Language CurrentLanguage;

  }



}
