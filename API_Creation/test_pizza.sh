#!/bin/bash

BASE_URL="http://localhost:5210/api/Pizza"

echo "============================================"
echo "      TESTING PIZZA API (CRUD)              "
echo "============================================"

# 1. GET ALL
echo "\n[1] Getting all pizzas..."
curl -s -X GET $BASE_URL | python3 -m json.tool

# 2. CREATE (POST)
echo "\n[2] Creating a new Pizza..."
RESPONSE=$(curl -s -X POST $BASE_URL \
   -H "Content-Type: application/json" \
   -d '{"name":"Margherita", "base":"Tomato", "price":12.5, "isVegetarian":true}')

echo "Response payload:"
echo $RESPONSE | python3 -m json.tool

# Extract ID
ID=$(echo $RESPONSE | python3 -c "import sys, json; print(json.load(sys.stdin)['id'])")
echo "\n>>> Created Pizza with ID: $ID"

if [ -z "$ID" ]; then
    echo "Error: Could not capture ID. Exiting."
    exit 1
fi

# 3. GET ONE
echo "\n[3] Getting Pizza #$ID..."
curl -s -X GET $BASE_URL/$ID | python3 -m json.tool

# 4. UPDATE (PUT)
echo "\n[4] Updating Pizza #$ID..."
curl -s -X PUT $BASE_URL/$ID \
   -H "Content-Type: application/json" \
   -d '{"id":'$ID', "name":"Pepperoni", "base":"Tomato", "price":14.0, "isVegetarian":false}'

# Verify Update
echo "\nVerifying update..."
curl -s -X GET $BASE_URL/$ID | python3 -m json.tool

# 5. DELETE
echo "\n[5] Deleting Pizza #$ID..."
curl -s -X DELETE $BASE_URL/$ID

# Verify Deletion
echo "\nVerifying deletion (Should be 404 Not Found)..."
HTTP_CODE=$(curl -s -o /dev/null -w "%{http_code}" -X GET $BASE_URL/$ID)
echo "HTTP Status Code: $HTTP_CODE"

echo "\n============================================"
echo "      TEST COMPLETED                        "
echo "============================================"
