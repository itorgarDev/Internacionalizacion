using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;

public class LocaleSelector : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    IEnumerator Start()
    {
        // Espera a que el sistema de localización se inicialice correctamente
        yield return LocalizationSettings.InitializationOperation;

        // Limpia las opciones actuales del dropdown
        dropdown.ClearOptions();

        // Obtener los idiomas disponibles en el proyecto
        var locales = LocalizationSettings.AvailableLocales.Locales;
        var options = new List<string>();
        int selectedIndex = 0;

        for (int i = 0; i < locales.Count; ++i)
        {
            options.Add(locales[i].Identifier.CultureInfo.NativeName); // Muestra el nombre nativo del idioma

            if (locales[i] == LocalizationSettings.SelectedLocale)
            {
                selectedIndex = i;
            }
        }

        dropdown.AddOptions(options);
        dropdown.value = selectedIndex;

        // Escucha cuando el usuario cambia la opción del dropdown
        dropdown.onValueChanged.AddListener(OnLocaleSelected);
    }

    private void OnLocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}