export const SHOW_ALERT = 'SHOW_ALERT'

export function showAlert(show, color, message) {
    return {
        type: SHOW_ALERT,
        show,
        color,
        message,
    }
}