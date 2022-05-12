import React from 'react'
import { motion } from 'framer-motion'

/**
 * # ServerMessage
 *
 * A regular text item for the UI, representing the server message.
 *
 * @param { Object } props Props for the component.
 * @returns { JSX.Element } An animated text element representing a server message in the UI.
 */
export default function ServerMessage({ message }) {
  return (
    <motion.h1
      initial="hidden"
      animate="visible"
      variants={{
        hidden: {
          opacity: 0,
          x: -20,
        },
        visible: {
          x: 0,
          opacity: 1,
        },
      }}
      className="text-center text-neutral-400"
    >
      {message.message}
    </motion.h1>
  )
}
