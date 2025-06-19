variable "resource_group_name" {
  description = "The name of the resource group"
  type        = string
}

variable "location" {
  description = "The Azure region to deploy resources"
  type        = string
}

variable "vnet_subnet_id" {
  description = "The ID of the subnet to deploy AKS into"
  type        = string
}

