import { SHOW_ALERT } from '../actions/showAlert'

const initialState = {
    show: false,
    color: '',
    message: '',
}

export default function alert(state = initialState, action) {
    switch (action.type) {
        case SHOW_ALERT: {
            return {
                ...state,
                show: action.show,
                color: action.color,
                message: action.message,
            }
        }
    }
    
    return state
}