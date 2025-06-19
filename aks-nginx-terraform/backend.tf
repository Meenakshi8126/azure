terraform {
  backend "azurerm" {
    resource_group_name  = "tfstate-rg"
    storage_account_name = "tfstateprodaksnginx"
    container_name       = "state"
    key                  = "staging.tfstate"
  }
}
