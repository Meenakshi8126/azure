 ┌────────────────────────┐
 │     Developer          │
 │    (Git Push to Repo)  │
 └──────────┬─────────────┘
            │
            ▼
 ┌──────────────────────────────┐
 │         Jenkins CI           │
 │  (Runs on Azure VM)          │
 └──────────┬───────────────────┘
            │
            ▼
 ┌────────────────────────────────────┐
 │         Terraform (IaC)            │
 │ • Creates VPC, Subnets             │
 │ • Provisions AKS (Azure Kubernetes)│
 │ • Sets up NSGs & LoadBalancer      │
 └──────────┬─────────────────────────┘
            │
            ▼
 ┌────────────────────────────────────────────┐
 │        Azure Kubernetes Service (AKS)      │
 │ • Cluster created                          │
 │ • Exposed via LoadBalancer                 │
 │ • kubectl configured locally or on VM      │
 └──────────┬──────────────────────────────────┘
            │
            ▼
 ┌────────────────────────────────────────┐
 │       Helm Chart Deployment            │
 │ • NGINX Helm chart located in repo     │
 │ • Deployed using `helm install`        │
 │ • Exposes NGINX via LoadBalancer IP    │
 └──────────┬─────────────────────────────┘
            │
            ▼
 ┌──────────────────────────────────────┐
 │           Azure Resources           │
 │ • VM with Jenkins + tools installed │
 │ • AKS Cluster running NGINX         │
 │ • NGINX accessible via public IP    │
 └──────────────────────────────────────┘

