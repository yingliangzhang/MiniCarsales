import { FETCHING_CARS, FETCHED_CARS } from '../actions/car/fetchCars'

const initialState = {
    fetchingCars: true,
    cars: [],
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
    }
    
    return state
}