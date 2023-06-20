# PowerPlant Coding Challenge

Welcome! This is a coding challenge that we ask applicants to perform when applying for a job in our team.

This is a very basic implementation of a powerplant dispatch engine. 
It is based on a simplified domain model of a powerplant composed of a set of gas fired power production units and wind powered power production units. 
The power produced by the gas fired units depends on the gas price and on the requested load. 
The power produced by the wind units depends on the wind speed and on the requested load.

# Returns
For any reason , if the application is not able to calculate the powerplant dispatch, it will return a message with the error 400 Bad Request and a description of the error.

## Requirement

- Docker: [Instalação do Docker](https://docs.docker.com/get-docker/)
- Git: [Instalação do Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

## Running the project

Siga as etapas abaixo para executar o projeto em um ambiente de desenvolvimento.

1. Repository clone:
   ```bash
   git clone https://github.com/leandroamorimlagoa/powerplant-coding-challenge.git
   ```

2. Access the project directory:
   ```bash
   cd nome-do-repositorio
   ```

3. Build the Docker image:
   ```bash
   docker build -t powerplant .
   ```

4. Run the container:
   ```bash
	docker run -p 8888:80 powerplant
	```

5. Using the application endpoint to test, you can use your browser:
   ```bash
   http://localhost:8888/api/PowerPlant
   ```

6. To test the application, you can you the Postman App with this curl:
   ```bash
	        curl --location 'http://localhost:8888/api/PowerPlant' \
                --header 'accept: text/plain' \
                --header 'Content-Type: application/json' \
                --data '{
                  "load": 480,
                  "fuels":
                  {
                    "gas(euro/MWh)": 13.4,
                    "kerosine(euro/MWh)": 50.8,
                    "co2(euro/ton)": 20,
                    "wind(%)": 60
                  },
                  "powerplants": [
                    {
                      "name": "gasfiredbig1",
                      "type": "gasfired",
                      "efficiency": 0.53,
                      "pmin": 100,
                      "pmax": 460
                    },
                    {
                      "name": "gasfiredbig2",
                      "type": "gasfired",
                      "efficiency": 0.53,
                      "pmin": 100,
                      "pmax": 460
                    },
                    {
                      "name": "gasfiredsomewhatsmaller",
                      "type": "gasfired",
                      "efficiency": 0.37,
                      "pmin": 40,
                      "pmax": 210
                    },
                    {
                      "name": "tj1",
                      "type": "turbojet",
                      "efficiency": 0.3,
                      "pmin": 0,
                      "pmax": 16
                    },
                    {
                      "name": "windpark1",
                      "type": "windturbine",
                      "efficiency": 1,
                      "pmin": 0,
                      "pmax": 150
                    },
                    {
                      "name": "windpark2",
                      "type": "windturbine",
                      "efficiency": 1,
                      "pmin": 0,
                      "pmax": 36
                    }
                  ]
                }'
	```