using Content.Shared._ES.Masks.Components;
using Content.Shared.Actions;
using Content.Shared.Popups;
using Robust.Shared.Prototypes;

namespace Content.Shared._ES.Masks;

public sealed class ESSenseAuraSystem : EntitySystem
{
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ESSenseAuraActionEvent>(OnSensedAura);
    }

    private void OnSensedAura(ESSenseAuraActionEvent args)
    {
        Log.Debug($"Sensed aura of {args.Target}");

        if (!TryComp<ESMaskRoleComponent>(args.Target, out var role) ||
            !role.Mask.HasValue ||
            !_prototypeManager.Resolve(role.Mask, out var mask) ||
            !_prototypeManager.Resolve(mask.Aura, out var aura)
        )
            return;

        _popup.PopupClient(Loc.GetString("es-oracle-sense-aura-popup", ("aura", aura.Name)), args.Target, args.Performer);
    }
}

public sealed partial class ESSenseAuraActionEvent : EntityTargetActionEvent;
