rule WMIEnumCommands_Yara {
    meta:
        last_updated = "2022-3-3"
        author = "Grimmie"
        description = "Searches for specific strings in an unmodified version of WMIEnum, specifically namespaces used and common commands"
        
    strings:
        // namespace strings
        $wmi_queryNamespace = "System.Mangement" ascii
        $reflectionNamespace = "System.Reflection" ascii
        // command strings
        $returnGroups1 = "ReturnGroups" ascii
        $returnGroups2 = "ReturnAllGroupMembers" ascii
        $returnGroups3 = "ReturnGroupMembers" ascii
        $returnUsers1 = "ReturnLoggedinUsers" ascii
        $returnUsers2 = "ReturnUsers" ascii
        $returnProcs = "ReturnTargetProcess" ascii
        // PE magic byte
        $PE_Magic_Byte = "MZ"

    condition:
        // check for PE magic byte at position 0
        $PE_Magic_Byte at 0 and
        // check for namespace strings
        ($wmi_queryNamespace and $reflectionNamespace)and
        // check for command strings
        all of $return*
}
