provider "azurerm" {
  features {}
  subscription_id = "f46c5aea-6d78-4485-b558-327eecd54457"
}

module "vnet" {
  source              = "./modules/vnet"
  resource_group_name = "azure-aks-nginx"
  location            = "eastasia"
}

module "aks" {
  source              = "./modules/aks"
  resource_group_name = "azure-aks-nginx"
  location            = "eastasia"
  vnet_subnet_id      = module.vnet.subnet_id
}

output "kube_config" {
  value     = module.aks.kube_config
  sensitive = true
}
