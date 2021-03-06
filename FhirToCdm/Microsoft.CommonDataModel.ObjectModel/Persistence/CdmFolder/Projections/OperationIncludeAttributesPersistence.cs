// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.CommonDataModel.ObjectModel.Persistence.CdmFolder
{
    using Microsoft.CommonDataModel.ObjectModel.Cdm;
    using Microsoft.CommonDataModel.ObjectModel.Enums;
    using Microsoft.CommonDataModel.ObjectModel.Persistence.CdmFolder.Types;
    using Microsoft.CommonDataModel.ObjectModel.Utilities;
    using Microsoft.CommonDataModel.ObjectModel.Utilities.Logging;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Operation IncludeAttributes persistence
    /// </summary>
    public class OperationIncludeAttributesPersistence
    {
        public static CdmOperationIncludeAttributes FromData(CdmCorpusContext ctx, JToken obj)
        {
            if (obj == null)
            {
                return null;
            }

            CdmOperationIncludeAttributes includeAttributesOp = ctx.Corpus.MakeObject<CdmOperationIncludeAttributes>(CdmObjectType.OperationIncludeAttributesDef);

            if (obj["$type"] != null && !StringUtils.EqualsWithIgnoreCase(obj["$type"].ToString(), OperationTypeConvertor.OperationTypeToString(CdmOperationType.IncludeAttributes)))
            {
                Logger.Error(nameof(OperationIncludeAttributesPersistence), ctx, $"$type {(string)obj["$type"]} is invalid for this operation.");
            }
            else
            {
                includeAttributesOp.Type = CdmOperationType.IncludeAttributes;
            }
            if (obj["explanation"] != null)
            {
                includeAttributesOp.Explanation = (string)obj["explanation"];
            }
            includeAttributesOp.IncludeAttributes = obj["includeAttributes"]?.ToObject<List<string>>();

            return includeAttributesOp;
        }

        public static OperationIncludeAttributes ToData(CdmOperationIncludeAttributes instance, ResolveOptions resOpt, CopyOptions options)
        {
            if (instance == null)
            {
                return null;
            }

            return new OperationIncludeAttributes
            {
                Type = OperationTypeConvertor.OperationTypeToString(CdmOperationType.IncludeAttributes),
                Explanation = instance.Explanation,
                IncludeAttributes = instance.IncludeAttributes,
            };
        }
    }
}
