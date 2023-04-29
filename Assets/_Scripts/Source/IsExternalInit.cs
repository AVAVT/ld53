/*
 * IsExternalInit is to provide support for record type in Unity 2021:
 * https://stackoverflow.com/questions/62648189/testing-c-sharp-9-0-in-vs2019-cs0518-isexternalinit-is-not-defined-or-imported/62656145#62656145
 *
 * When Unity support record type natively this file should be removed
 */

using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public record IsExternalInit;
}