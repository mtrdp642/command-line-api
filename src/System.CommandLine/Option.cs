﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.CommandLine.Binding;
using System.Linq;

namespace System.CommandLine
{
    public class Option : Symbol, IOption
    {
        public Option(
            IReadOnlyCollection<string> aliases,
            string description = null,
            Argument argument = null,
            bool isHidden = false)
            : base(aliases, description, argument, isHidden)
        {
        }

        public Option(
            string alias,
            string description = null,
            Argument argument = null,
            bool isHidden = false)
            : base(new[]
            {
                alias
            }, description, argument, isHidden)
        {
        }

        public virtual Argument Argument
        {
            get => _arguments.FirstOrDefault() ?? Argument.None;
            set
            {
                if (_arguments.Any())
                {
                    _arguments.Clear();
                }

                AddArgumentInner(value);
            }
        }

        IArgument IOption.Argument => Argument;

        Type IValueDescriptor.Type => _arguments[0].ArgumentType;

        bool IValueDescriptor.HasDefaultValue => _arguments[0].HasDefaultValue;

        object IValueDescriptor.GetDefaultValue() => _arguments[0].GetDefaultValue();
    }
}
