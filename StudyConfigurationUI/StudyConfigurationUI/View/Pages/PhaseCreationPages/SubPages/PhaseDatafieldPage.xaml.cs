﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages.SubPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhaseDatafieldPage : Page
    {
        public PhaseDatafieldPage()
        {
            this.InitializeComponent();
        }

        private void DataFieldCreationWindow_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void IsModifiableCheckbox_OnChecked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async void AddDatafieldBut_OnClick(object sender, RoutedEventArgs e)
        {
            await DataFieldCreationWindow.ShowAsync();
        }
    }
}