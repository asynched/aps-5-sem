import React from 'react'
import { motion } from 'framer-motion'
import { getUserImage } from '@/services/images'

/**
 * # UserMessage
 *
 * A regular message component for other users.
 *
 * @param { Object } props Props for the component.
 * @returns { JSX.Element } A UI component for the regular user messages.
 */
export default function UserMessage({ message }) {
  return (
    <motion.div
      initial="hidden"
      animate="visible"
      variants={{
        hidden: {
          y: 24,
          opacity: 0,
        },
        visible: {
          y: 0,
          opacity: 1,
        },
      }}
      transition={{ duration: 0.5 }}
      className="flex items-start gap-4"
    >
      <img
        className="h-8 w-8 rounded-full"
        src={getUserImage(message.user)}
        alt={message.user}
      />
      <div
        className="mr-auto rounded-b-2xl rounded-tr-2xl bg-message-purple-dark py-3 px-4"
        key={message.id}
      >
        <p>{message.message}</p>
      </div>
    </motion.div>
  )
}
