import car from './car'
import { FETCHING_CARS, FETCHED_CARS } from '../actions/car/fetchCars'
import { CREATING_CAR, CREATED_CAR } from '../actions/car/createCar'
import { FETCHING_BODY_TYPES, FETCHED_BODY_TYPES } from '../actions/car/fetchBodyTypes'

describe('reducers/car', function() {
    let initialState

	beforeEach(function() {
		initialState = car({
            fetchingCars: true,
            creatingCars: false,
            fetchingBodyTypes: false,
            cars: [],
            bodyTypes: [],
        }, {
			type: 'test'
		})
    })
    
    test('Initial state', () => {
		expect(initialState).toEqual({
            fetchingCars: true,
            creatingCars: false,
            fetchingBodyTypes: false,
            cars: [],
            bodyTypes: [],
        })
    })
    
    test('set FETCHING_CARS correctly', () => {
        let state = car(initialState, {
            type: FETCHING_CARS,
        })

        expect(state).toEqual({
            ...initialState,
            fetchingCars: true,
        })
    })

    test('set FETCHED_CARS correctly', () => {
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

        let state = car(initialState, {
            type: FETCHED_CARS,
            cars
        })

        expect(state).toEqual({
            ...initialState,
            fetchingCars: false,
            cars,
        })
    })

    test('set CREATING_CAR correctly', () => {
        let state = car(initialState, {
            type: CREATING_CAR,
        })

        expect(state).toEqual({
            ...initialState,
            creatingCars: true,
        })
    })

    test('set CREATED_CAR correctly', () => {
        const newCar = {
            "numberOfWheels": 4,
            "numberOfDoors": 5,
            "engine": "1.4T",
            "bodyType": "Hatchback",
            "make": "VW",
            "model": "Golf",
        }

        let state = car(initialState, {
            type: CREATED_CAR,
            newCar
        })

        expect(state).toEqual({
            ...initialState,
            creatingCars: false,
            cars: [newCar],
        })
    })

    test('set FETCHING_BODY_TYPES correctly', () => {
        let state = car(initialState, {
            type: FETCHING_BODY_TYPES,
        })

        expect(state).toEqual({
            ...initialState,
            fetchingBodyTypes: true,
        })
    })

    test('set FETCHED_BODY_TYPES correctly', () => {
        const bodyTypes = ['Sedan', 'Hatchback']
        let state = car(initialState, {
            type: FETCHED_BODY_TYPES,
            bodyTypes
        })

        expect(state).toEqual({
            ...initialState,
            fetchingBodyTypes: false,
            bodyTypes
        })
    })
})