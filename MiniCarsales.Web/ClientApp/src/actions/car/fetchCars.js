import fetch from 'cross-fetch'
import { showAlert } from '../showAlert';

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
        try {
            dispatch(fetchingCars())
            const response = await fetch('/api/cars')
            const cars = await response.json()
            dispatch(fetchedCars(cars))
        } catch (error) {
            dispatch(showAlert(true, 'danger', `There was an error fetching cars, please try again. ${error}`))
        }
    }
}