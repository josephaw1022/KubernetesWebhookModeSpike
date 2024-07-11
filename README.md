# Creating the Certification

This guide provides instructions on how to create and trust an HTTPS development certificate using the .NET CLI tool, specifically tailored for a PowerShell environment on Windows.

## Prerequisites

- .NET SDK: Ensure you have the .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).

## Instructions

### Step 1: Create and Trust the HTTPS Certificate

1. **Generate the Certificate**: Run the following command in PowerShell to generate a PEM-formatted HTTPS certificate and save it to your specified path. Replace `"your_password"` with a strong password of your choice.

   ```powershell
   dotnet dev-certs https -ep "C:\Users\josep\.aspnet\https\certificate.crt" -p "your_password" --trust --format PEM
   ```

   - `-ep` specifies the export path for the certificate.
   - `-p` sets the password for the certificate.
   - `--trust` will make the certificate trusted on your system.
   - `--format PEM` exports the certificate in PEM format.

2. **Trust the Certificate**: When executing the command, a prompt may appear asking for confirmation to trust the certificate. Click "Yes" to proceed. This step is crucial as it allows the certificate to be trusted by your local machine, enabling HTTPS development without browser warnings.

### Step 2: Verify the Certificate Files

1. **List the Certificate Files**: Ensure that the certificate files are correctly created by listing the contents of the directory where you exported them. Run:

   ```powershell
   ls "C:\Users\josep\.aspnet\https"
   ```

   You should see files like `certificate.crt`, `certificate.key`, and possibly others depending on your previous uses of the .NET development certificate tool.


# Local Kubernetes Webhook Cluster with .NET Web API Integration

This repository contains all the necessary components to set up a local Kubernetes cluster in webhook mode and have it callback to a .NET Web API. The setup is designed to run a Kubernetes webhook that integrates seamlessly with a .NET Web API, facilitating a development environment for webhook testing and functionality demonstrations.

## Project Structure

```
.
├── helm                # Helm chart for the Kubernetes webhook configuration
├── src                 # Source code for the .NET Web API
└── README.md           # Documentation and setup instructions
```

## Prerequisites

- Docker Desktop or any Kubernetes-compatible local environment like Rancher Desktop or Minikube
- Helm 3
- .NET 8.0 SDK
- Dotnet Aspire

## Setup Instructions

### 1. Setting Up the .NET Web API

Navigate to the `src` directory where the .NET Web API code is located:

```bash
cd src
```

Build and run the .NET application:

```bash
dotnet restore
dotnet build
dotnet run
```

### 2. Deploying the Kubernetes Webhook

Before deploying the Helm chart, make sure your Kubernetes cluster is running and kubectl is configured to interact with it.

Deploy the Helm chart located in the `helm` directory:

```bash
helm install webhook ./helm
```

This command deploys the Kubernetes resources defined in the Helm chart, including the necessary configurations for the webhook to communicate with the .NET Web API.

### 3. Verifying the Deployment

Verify that the webhook is up and running:

```bash
kubectl get all
```

This command should list all the resources, including the webhook service and any associated pods.

### 4. Testing the Webhook

To test the webhook's functionality, send a request to the exposed service or use the provided testing scripts in the `src` directory.

## Configuration

- **Webhook URL**: The URL where the webhook is listening can be found in the service description provided by `kubectl get svc`.

- **.NET Web API Endpoints**: Modify the endpoints in the `.NET` project to handle incoming webhook requests appropriately.
