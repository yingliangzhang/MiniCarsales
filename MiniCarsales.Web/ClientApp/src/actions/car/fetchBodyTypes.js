import fetch from 'cross-fetch'
import { showAlert } from '../showAlert';

export const FETCHING_BODY_TYPES = 'FETCHING_BODY_TYPES'
export const FETCHED_BODY_TYPES = 'FETCHED_BODY_TYPES'

function fetchingBodyTypes() {
    return {
        type: FETCHING_BODY_TYPES
    }
}

function fetchedBodyTypes(bodyTypes) {
    return {
        type: FETCHED_BODY_TYPES,
        bodyTypes
    }
}

export function fetchBodyTypes() {
    return async(dispatch) => {
        try {
            dispatch(fetchingBodyTypes())
            const response = await fetch('/api/cars/body-types')
            const bodyTypes = await response.json()
            dispatch(fetchedBodyTypes(bodyTypes))
        } catch (error) {
            dispatch(showAlert(true, 'danger', `There was an error fetching body types, please try again. ${error}`))
        }
        
    }
}