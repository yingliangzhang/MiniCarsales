jest.mock('cross-fetch');

import { createCar, CREATED_CAR } from './createCar'
import fetch from 'cross-fetch'


describe('createCar', () => {
    const mockDispatch = jest.fn()
    const newCar = {
        "numberOfWheels": 4,
        "numberOfDoors": 4,
        "engine": "2.0L",
        "bodyType": "Sedan",
        "make": "BMW",
        "model": "320i",
    }

    test('When create succeeds CREATED_CAR action is called', async() => {
        const createCarThunk = createCar()
        fetch.mockReturnValue(Promise.resolve(new Response(JSON.stringify(newCar))));
        await createCarThunk(mockDispatch)
        
        expect(fetch).toHaveBeenCalledTimes(1);
        expect(fetch).toHaveBeenCalledWith('/api/cars', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
        });
		expect(mockDispatch).toHaveBeenCalledWith({
			type: CREATED_CAR,
			newCar,
		})
	})
})