# README - Lambda + Api Gateway.

# Prerequisites: 
1 - AWS CLI
2 - SAM CLI
3 - Dotnet 8 
4 - Docker 


# Validate the installation 

```
aws --version
```

```
sam --version
```

```
dotnet --version
```

```
docker --version 
```

```
dynamodb-admin --version
```

# Run the project

1 - Pull a image of DynamoDB not test locally 
```
docker pull amazon/dynamodb-local
```

2 - Run the DynamoDB image
```
docker run -d -p 8000:8000 amazon/dynamodb-local
```

3 - Validate DynamoDB is running
```
dockers ps
```

4 - List tables in your DynamoDB
```
aws --endpoint-url http://localhost:8000  dynamodb list-tables
```

5 - Create `Users` table
```
aws dynamodb create-table \
  --table-name Users \
  --attribute-definitions AttributeName=Id,AttributeType=S \
  --key-schema AttributeName=Id,KeyType=HASH \
  --billing-mode PAY_PER_REQUEST \
  --endpoint-url http://localhost:8000
```

6 - Run dynamodb-admin and access to the UI on `http://0.0.0.0:8001/`
```
DYNAMO_ENDPOINT=http://localhost:8000 AWS_ACCESS_KEY_ID=<Copy_your_access_key_id> AWS_SECRET_ACCESS_KEY=<Copy_your_secret_access_key> dynamodb-admin
```

7 - Run the project
```
dotnet run
```
