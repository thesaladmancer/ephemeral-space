using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.Array;

namespace Content.Shared._ES.Masks;

[Prototype("esAura")]
public sealed partial class ESAuraPrototype : IPrototype, IInheritingPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; } = default!;

    /// <inheritdoc/>
    [ParentDataField(typeof(AbstractPrototypeIdArraySerializer<ESAuraPrototype>))]
    public string[]? Parents { get; }

    [AbstractDataField]
    public bool Abstract { get; }

    /// <summary>
    /// Name used for UI.
    /// </summary>
    [DataField]
    public LocId Name;

    /// <summary>
    /// Color used for UI.
    /// </summary>
    [DataField]
    public Color Color = Color.White;
}
