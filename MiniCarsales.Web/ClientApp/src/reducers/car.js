import { FETCHING_CARS, FETCHED_CARS } from '../actions/car/fetchCars'
import { CREATING_CAR, CREATED_CAR } from '../actions/car/createCar'
import { FETCHING_BODY_TYPES, FETCHED_BODY_TYPES } from '../actions/car/fetchBodyTypes'

const initialState = {
    fetchingCars: true,
    creatingCars: false,
    fetchingBodyTypes: false,
    cars: [],
    bodyTypes: [],
}

export default function car(state = initialState, action) {
    switch (action.type) {
        case FETCHING_CARS: {
            return {
                ...state,
                fetchingCars: true,
            }
        }
        case FETCHED_CARS: {
            return {
                ...state,
                cars: action.cars,
                fetchingCars: false,
            }
        }
        case CREATING_CAR: {
            return {
                ...state,
                creatingCars: true,
            }
        }
        case CREATED_CAR: {
            return {
                ...state,
                creatingCars: false,
                cars: [...state.cars, action.newCar],
            }
        }
        case FETCHING_BODY_TYPES: {
            return {
                ...state,
                fetchingBodyTypes: true,
            }
        }
        case FETCHED_BODY_TYPES: {
            return {
                ...state,
                fetchingBodyTypes: false,
                bodyTypes: action.bodyTypes,
            }
        }
    }
    
    return state
}