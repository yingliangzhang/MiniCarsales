import React from 'react';
import { shallow } from 'enzyme';
import { Spinner } from 'reactstrap'
import { Cars } from './Cars'
import CarCard from './CarCard'

describe('<Cars />', () => {
    test('Renders spinner when fetching cars', () => {
        const fetchCars = jest.fn()
        const fetchingCars = true
        const cars = []

        const wrapper = shallow(<Cars
            fetchCars={fetchCars}
            fetchingCars={fetchingCars}
            cars={cars}
        />)
        expect(fetchCars).toHaveBeenCalled()
        expect(wrapper.find(Spinner)).toHaveLength(1)
    })

    test('Renders 2 car cards with 2 cars', () => {
        const fetchCars = jest.fn()
        const fetchingCars = false
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

        const wrapper = shallow(<Cars
            fetchCars={fetchCars}
            fetchingCars={fetchingCars}
            cars={cars}
        />)
        expect(fetchCars).toHaveBeenCalled()
        expect(wrapper.find(CarCard)).toHaveLength(2)
    })
})