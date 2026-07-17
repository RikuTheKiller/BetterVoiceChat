# Third-Party Notices

This project uses the following third-party packages. Each is listed with its
license and, where applicable, the full license text as required by that
license.

---

## BepInEx.Analyzers 1.0.8
**License:** MIT

## BepInEx.AssemblyPublicizer.MSBuild 0.4.2
**License:** MIT

## BepInEx.Core 5.4.21
**License:** MIT

## BepInEx.PluginInfoProps 2.1.0
**License:** MIT

## Newtonsoft.Json 13.0.4
**License:** MIT

> MIT License
>
> Copyright (c) BepInEx contributors / Newtonsoft.Json contributors (see individual project repositories for exact copyright holders)
>
> Permission is hereby granted, free of charge, to any person obtaining a copy
> of this software and associated documentation files (the "Software"), to deal
> in the Software without restriction, including without limitation the rights
> to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
> copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
>
> The above copyright notice and this permission notice shall be included in all
> copies or substantial portions of the Software.
>
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
> IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
> FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
> AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
> LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
> OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
> SOFTWARE.

---

## Lib.Harmony 2.4.2
**License:** MIT

> MIT License
>
> Copyright (c) 2017 Andreas Pardeike
>
> Permission is hereby granted, free of charge, to any person obtaining a copy
> of this software and associated documentation files (the "Software"), to deal
> in the Software without restriction, including without limitation the rights
> to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
> copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
>
> The above copyright notice and this permission notice shall be included in all
> copies or substantial portions of the Software.
>
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
> IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
> FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
> AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
> LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
> OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
> SOFTWARE.

---

## SpeexDSPSharp 1.3.0
## SpeexDSPSharp.Core 1.3.0
**License:** MIT

> MIT License
>
> Copyright (c) 2026 AvionBlock
>
> Permission is hereby granted, free of charge, to any person obtaining a copy
> of this software and associated documentation files (the "Software"), to deal
> in the Software without restriction, including without limitation the rights
> to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
> copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
>
> The above copyright notice and this permission notice shall be included in all
> copies or substantial portions of the Software.
>
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
> IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
> FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
> AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
> LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
> OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
> SOFTWARE.

### SpeexDSPSharp.Natives 1.3.0
**License:** MIT (wrapper) **+** BSD (bundled native speexdsp library)

The `SpeexDSPSharp.Natives` package bundles precompiled native binaries of the
`speexdsp` C library, which carries its own BSD-style license separate from
the MIT-licensed C# wrapper:

> Copyright 2002-2008  Xiph.org Foundation
> Copyright 2002-2008  Jean-Marc Valin
> Copyright 2005-2007  Analog Devices Inc.
> Copyright 2005-2008  Commonwealth Scientific and Industrial Research
>                      Organisation (CSIRO)
> Copyright 1993, 2002, 2006 David Rowe
> Copyright 2003       EpicGames
> Copyright 1992-1994  Jutta Degener, Carsten Bormann
>
> Redistribution and use in source and binary forms, with or without
> modification, are permitted provided that the following conditions
> are met:
>
> - Redistributions of source code must retain the above copyright
> notice, this list of conditions and the following disclaimer.
>
> - Redistributions in binary form must reproduce the above copyright
> notice, this list of conditions and the following disclaimer in the
> documentation and/or other materials provided with the distribution.
>
> - Neither the name of the Xiph.org Foundation nor the names of its
> contributors may be used to endorse or promote products derived from
> this software without specific prior written permission.
>
> THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
> ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
> LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
> A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE FOUNDATION OR
> CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
> EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
> PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
> PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
> LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
> NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
> SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

---

## Build-time-only dependencies (not distributed)

The following packages are used only at compile time and are not included in
the shipped build output. They are listed here for completeness but generally
do not require notices in a distributed product.

### Microsoft.NETFramework.ReferenceAssemblies 1.0.2
**License:** MIT (tooling repository) — reference assemblies only, not shipped.

### UnityEngine.Modules 2022.3.62
Reference stubs for compiling against the Unity Engine API; governed by the
Unity Editor software license, not an independent open-source license. Not
shipped as part of this project's build output.
