﻿using System;
using Toggl.Core.DTOs;
using Toggl.Core.Models.Interfaces;

namespace Toggl.Core.Interactors
{
    public sealed partial class InteractorFactory : IInteractorFactory
    {
        public IInteractor<IObservable<IThreadSafePreferences>> ObserveCurrentPreferences()
            => new ObservePreferencesInteractor(dataSource);

        public IInteractor<IObservable<IThreadSafePreferences>> UpdatePreferences(EditPreferencesDTO preferencesDto)
            => new UpdatePreferencesInteractor(dataSource.Preferences, preferencesDto);
    }
}
