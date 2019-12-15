jest.mock('cross-fetch');

import { fetchCars, FETCHED_CARS } from './fetchCars'
import fetch from 'cross-fetch'


describe('fetchCars', () => {
    const mockDispatch = jest.fn()
    const cars = [
        {
            "numberOfWheels": 4,
            "numberOfDoors": 4,
            "engine": "2.0L",
            "bodyType": "Sedan",
            "id": "f6490c92-671c-4866-a505-d38c8cd69124",
            "type": "Car",
            "make": "BMW",
            "model": "320i",
            "createdAt": "2019-12-14T17:11:34.8267308",
            "updatedAT": "2019-12-14T17:11:34.8284664"
        },
        {
            "numberOfWheels": 4,
            "numberOfDoors": 5,
            "engine": "1.4T",
            "bodyType": "Hatchback",
            "id": "d6ef4669-1285-4126-8437-69e151b9bb79",
            "type": "Car",
            "make": "VW",
            "model": "Golf",
            "createdAt": "2019-12-14T17:11:34.8292111",
            "updatedAT": "2019-12-14T17:11:34.8292127"
        }
    ];

    test('When fetch succeeds FETCHED_CARS action is called', async() => {
        const fetchCarsThunk = fetchCars()
        fetch.mockReturnValue(Promise.resolve(new Response(JSON.stringify(cars))));
        await fetchCarsThunk(mockDispatch)
        
        expect(fetch).toHaveBeenCalledTimes(1);
        expect(fetch).toHaveBeenCalledWith('/api/cars');
		expect(mockDispatch).toHaveBeenCalledWith({
			type: FETCHED_CARS,
			cars,
		})
	})
})