resource "azurerm_kubernetes_cluster" "aks" {
  name                = "nginx-aks"
  location            = var.location
  resource_group_name = var.resource_group_name
  dns_prefix          = "nginx"

  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_DS2_v2"
    vnet_subnet_id = var.vnet_subnet_id
  }

  network_profile {
    network_plugin   = "azure"          # CNI plugin
    network_policy   = "azure"          # optional
    service_cidr     = "10.240.0.0/16"  # <‑– NEW, outside the VNet
    dns_service_ip   = "10.240.0.10"    # <‑– any IP inside service_cidr
  }

  identity {
    type = "SystemAssigned"
  }
}

output "kube_config" {
  value = azurerm_kubernetes_cluster.aks.kube_config_raw
  sensitive = true
}

