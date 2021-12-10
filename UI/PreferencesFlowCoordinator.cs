﻿using HMUI;

namespace JDFixer.UI
{
    public class PreferencesFlowCoordinator : FlowCoordinator
    {
        public MainFlowCoordinator _ParentFlow;
        private PreferencesListViewController _prefListView;
        private RTPreferencesListViewController _rtPrefListView;

        public PreferencesFlowCoordinator(MainFlowCoordinator ParentFlow, PreferencesListViewController prefListView, RTPreferencesListViewController rtPrefListView)
        {
            _ParentFlow = ParentFlow;
            _prefListView = prefListView;
            _rtPrefListView = rtPrefListView;
        }

        /*public void Awake()
        {
            if (_rtPrefListView == null)
                _rtPrefListView = BeatSaberMarkupLanguage.BeatSaberUI.CreateViewController<RTPreferencesListViewController>();

            if (_prefListView == null)
                _prefListView = BeatSaberMarkupLanguage.BeatSaberUI.CreateViewController<PreferencesListViewController>();
        }*/

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                showBackButton = true;
                SetTitle("JDFixer Preferences");
            }

            if (PluginConfig.Instance.rt_enabled)
                ProvideInitialViewControllers(_rtPrefListView);

            else
                ProvideInitialViewControllers(_prefListView);
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            //ParentFlow.InvokeMethod("DismissFlowCoordinator", this, ViewController.AnimationDirection.Horizontal, null, false); ;
            _ParentFlow.Dissmiss
        }
    }
}
