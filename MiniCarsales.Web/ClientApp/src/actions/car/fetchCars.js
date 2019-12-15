import fetch from 'cross-fetch'

export const FETCHING_CARS = 'FETCHING_CARS'
export const FETCHED_CARS = 'FETCHED_CARS'

function fetchingCars() {
    return {
        type: FETCHING_CARS
    }
}

function fetchedCars(cars) {
    return {
        type: FETCHED_CARS,
        cars
    }
}

export function fetchCars() {
    return async(dispatch) => {
        dispatch(fetchingCars())
        const response = await fetch('/api/cars')
        const cars = await response.json()
        dispatch(fetchedCars(cars))
    }
}