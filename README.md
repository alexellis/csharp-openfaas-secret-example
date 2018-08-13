csharp-secret
===================

This OpenFaaS sample shows how to use an api-key secret to add authentication to a function.

```sh
KEY=$(head -c 2048 /dev/urandom | shasum | cut -d " " -f 1)
echo -n $KEY | docker secret create api-key -

echo "Your key is: $KEY"
09f62255f206eea5ae0481feadc22d3092706b4a

# Replace my Docker Hub Account for yours:

sed -ie s/alexellis2/yourdockerhubname/g stack.yml

# Build / push / deploy

faas-cli build \
 && faas-cli push \
 && faas-cli deploy

# Invoke the function without passing the Authorization header:

curl http://127.0.0.1:8080/function/csharp-secret -i
HTTP/1.1 500 Internal Server Error
Content-Length: 27
Content-Type: text/plain; charset=utf-8
Date: Mon, 13 Aug 2018 19:02:59 GMT
X-Call-Id: c0f9f0a6-574f-4f82-af8e-c556076d7360
X-Start-Time: 1534186979552841505

exit status 1
unauthorized

# Now try with the Authorization header:

curl http://127.0.0.1/function/csharp-secret -i -H "Authorization: Bearer 09f62255f206eea5ae0481feadc22d3092706b4a"
HTTP/1.1 200 OK
Content-Length: 16
Content-Type: text/plain; charset=utf-8
Date: Mon, 13 Aug 2018 19:02:48 GMT
X-Call-Id: 73ab26a4-76aa-41e1-b650-713bbb1b749f
X-Duration-Seconds: 0.068224
X-Start-Time: 1534186968746336001

Authorized.. OK

```
