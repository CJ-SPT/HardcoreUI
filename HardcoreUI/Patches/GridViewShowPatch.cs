﻿using Aki.Reflection.Patching;
using EFT.InventoryLogic;
using EFT.UI;
using EFT.UI.DragAndDrop;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace StashSearch.Patches
{
    internal class ContainersPanelShowPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(ContainersPanel), nameof(ContainersPanel.Show));
        }

        [PatchPostfix]
        public static void PatchPostfix(ContainersPanel __instance, EquipmentClass equipment, Dictionary<EquipmentSlot, SlotView> ___dictionary_0, 
            InventoryControllerClass inventoryController)
        {
            Slot slot = equipment.GetSlot(EquipmentSlot.SecuredContainer);
            IItemOwner owner = slot.ParentItem.Parent.GetOwner();

            if (owner != inventoryController)
            {
                return;
            }

            ___dictionary_0[EquipmentSlot.SecuredContainer].gameObject.SetActive(false);

            foreach (var rectTransform in ___dictionary_0[EquipmentSlot.Pockets].GetComponentsInChildren(typeof(RectTransform)))
            {
                if (rectTransform.gameObject.name == "Special Slots Panel Template")
                {
                    rectTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}