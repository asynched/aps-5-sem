/**
 * # preventDefault
 *
 * A UI modifier to prevent the default action of a given HTML element.
 *
 * @param { (event: SubmitEvent) => void } handler Function handler for the event.
 * @returns { (event: SubmitEvent) => void } A curried function to handle the submit event.
 */
export const preventDefault = (handler) => (event) => {
  event.preventDefault()
  handler(event)
}
