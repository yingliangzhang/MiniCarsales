import { combineReducers } from 'redux'
// import { connectRouter } from 'connected-react-router'
import car from './car'

// const createRootReducer = (history) =>  combineReducers({
// 	car,
// 	router: connectRouter(history),
// })

// export default createRootReducer

export default combineReducers({ car })