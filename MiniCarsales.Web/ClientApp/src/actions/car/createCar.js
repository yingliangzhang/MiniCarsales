import fetch from 'cross-fetch'
import { showAlert } from '../showAlert';

export const CREATING_CAR = 'CREATING_CAR'
export const CREATED_CAR = 'CREATED_CAR'

function creatingCar() {
    return {
        type: CREATING_CAR
    }
}

function createdCar(newCar) {
    return {
        type: CREATED_CAR,
        newCar
    }
}

export function createCar(car) {
    return async(dispatch) => {

        try {
            dispatch(creatingCar())
            const response = await fetch('/api/cars', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(car)
            })
  
            if (!response.ok) {
                throw new Error(`${response.status} - ${response.statusText}`)
            }

            const newCar = await response.json()
            dispatch(createdCar(newCar))
            dispatch(showAlert(true, 'success', 'New car has been created'))
            return newCar
        } catch (error) {
            dispatch(showAlert(true, 'danger', `There was an error creating new car, please try again. ${error}`))
            throw error
        }
    }
}
